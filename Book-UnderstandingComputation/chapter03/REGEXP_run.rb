require './REGEXP.rb'

pattern = Repeat.new(
  Choose.new(
    Concatenate.new(Literal.new('a'), Literal.new('b')),
    Literal.new('a')
  )
)

p pattern

p '---------------------'

nfa_design = Empty.new.to_nfa_design

p nfa_design.accepts?('')
p nfa_design.accepts?('a')

nfa_design = Literal.new('a').to_nfa_design

p nfa_design.accepts?('')
p nfa_design.accepts?('a')
p nfa_design.accepts?('b')

p '--------matches---------'
p Empty.new.matches?('a')
p Literal.new('a').matches?('a')

p '------- Concatenate ------------'
pattern = Concatenate.new(
  Literal.new('a'),
  Concatenate.new(Literal.new('b'), Literal.new('c'))
)

p pattern

p pattern.matches?('a')
p pattern.matches?('ab')
p pattern.matches?('abc')


p '------- Choose ----------------'

pattern = Choose.new(Literal.new('a'), Literal.new('b'))
p pattern

p pattern.matches? 'a'
p pattern.matches? 'b'
p pattern.matches? 'c'


p '------- Repeat --------'

pattern = Repeat.new(Literal.new('a'))
p pattern

p pattern.matches? ''
p pattern.matches? 'a'
p pattern.matches? 'aaaa'
p pattern.matches? 'b'

p '------- 複雑なパターン -------------'
pattern =
  Repeat.new(
    Concatenate.new(
      Literal.new('a'),
      Choose.new(Empty.new, Literal.new('b'))
    )
)

p pattern


require 'treetop'
Treetop.load('pattern')


parse_tree = PatternParser.new.parse('(a(|b))*');

pattern = parse_tree.to_ast
p pattern.matches? 'abaab'
p pattern.matches? 'abba'

