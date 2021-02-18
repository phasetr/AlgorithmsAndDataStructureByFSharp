require './lexer'

puts LexicalAnalyzer.new('y=x*7').analyze.inspect
