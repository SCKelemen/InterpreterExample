package main

import (
	"fmt"
)

type Token rune

const (
	ONE         Token = 'I'
	FIVE        Token = 'V'
	TEN         Token = 'X'
	FIFTY       Token = 'L'
	HUNDRED     Token = 'C'
	FIVEHUNDRED Token = 'D'
	THOUSAND    Token = 'M'
)

type Parser struct {
	current     rune
	next        rune
	index       int
	accumulator int
}

func (p *Parser) Parse(s string) int {

	// XIV 14
	var accumulator int = 0
	for char, num := range s {
		switch Token(char) {
		case THOUSAND:
			accumulator += 1000
			break
		case FIVEHUNDRED:
			accumulator += 500
			break
		case HUNDRED:
			switch Token(s[num]) {
			case FIVEHUNDRED:
			case THOUSAND:
				accumulator -= 100
				break
			default:
				accumulator += 100
				break
			}
			// can precede D or M
			break
		case FIFTY:
			accumulator += 50
			break
		case TEN:
			fmt.Println("triggered")
			// can precede L or C
			switch Token(s[num]) {
			case FIFTY:
			case HUNDRED:
				accumulator -= 10
				break
			default:
				accumulator += 10
			}
		case ONE:
			// can precede V or X
			switch Token(s[num]) {
			case FIVE:
			case TEN:
				accumulator -= 1
				break
			default:
				accumulator += 1
				break
			}
			break
		default:
			break
		}
	}
	fmt.Println(accumulator)
	return p.accumulator
}
func main() {
	var parser = Parser{accumulator: 10}
	fmt.Println(parser.Parse("XIX"))
	fmt.Println(parser.accumulator)
}
