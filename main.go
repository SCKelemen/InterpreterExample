package main

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
	p.current = rune(s[0])

	// XIV 14
	for char, _ := range s {
		switch Token(char) {
		case THOUSAND:

			break
		case FIVEHUNDRED:
			break
		case HUNDRED:

			break
		case FIFTY:
			break
		case TEN:

			break
		case ONE:
			break
		default:
			break
		}
	}
	return p.accumulator
}
func main() {

}
