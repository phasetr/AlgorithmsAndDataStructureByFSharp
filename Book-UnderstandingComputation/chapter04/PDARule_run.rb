require './pda.rb'

rule = PDARule.new(1, '(', 2, '$', ['b', '$'])
p rule

configuration = PDAConfiguration.new(1, Stack.new(['$']))
p configuration

p rule.applies_to?(configuration, '(')

p '------------------------------'

p rule.follow(configuration)

p '------------------------------'

rulebook = DPDARulebook.new([
  PDARule.new(1, '(', 2, '$', ['b', '$']),
  PDARule.new(2, '(', 2, 'b', ['b', 'b']),
  PDARule.new(2, ')', 2, 'b', []),
  PDARule.new(2, nil, 1, '$', ['$'])
])

p configuration = rulebook.next_configuration(configuration, '(')
p configuration = rulebook.next_configuration(configuration, '(')
p configuration = rulebook.next_configuration(configuration, ')')

p '---------------DPDA--------------'

dpda = DPDA.new(PDAConfiguration.new(1, Stack.new(['$'])), [1], rulebook)
p dpda.accepting?

dpda.read_string('(()')
p dpda.accepting?

p dpda.current_configuration

p '---------------freemove--------------'

configuration = PDAConfiguration.new(2, Stack.new(['$']))
p configuration

rulebook.follow_free_moves(configuration)
p rulebook

p '---------------)))))-----------------'

dpda = DPDA.new(PDAConfiguration.new(1, Stack.new(['$'])), [1], rulebook)

dpda.read_string('(()(')
p dpda.accepting?

p dpda.current_configuration
dpda.read_string('))()')
p dpda.accepting?

p dpda.current_configuration

p '---------------design ---------------'
dpda_design = DPDADesign.new(1, '$', [1], rulebook)
p dpda_design.accepts?('(((((())))))')
p dpda_design.accepts?('()()()()(((((()()))))')
p dpda_design.accepts?('((()()()()((()()))))(')

#p '-------------design?-----------------'
#dpda = DPDA.new(PDAConfiguration.new(1, Stack.new(['$'])), [1], rulebook)
#dpda.read_string('())')
#p dpda.current_configuration

#p dpda_design.accepts?('())')
#
p '-----ab-----'
rulebook = DPDARulebook.new([
  PDARule.new(1, 'a', 2, '$', ['a', '$']),
  PDARule.new(1, 'b', 2, '$', ['b', '$']),
  PDARule.new(2, 'a', 2, 'a', ['a', 'a']),
  PDARule.new(2, 'b', 2, 'b', ['b', 'b']),
  PDARule.new(2, 'a', 2, 'b', []),
  PDARule.new(2, 'b', 2, 'a', []),
  PDARule.new(2, nil, 1, '$', ['$'])
])

dpda_design = DPDADesign.new(1, '$', [1], rulebook)
p dpda_design.accepts?('ababab')
p dpda_design.accepts?('bbbaaaab')
p dpda_design.accepts?('baa')
