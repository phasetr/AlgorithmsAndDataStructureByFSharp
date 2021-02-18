require './pda'

rulebook = NPDARulebook.new([
  PDARule.new(1, 'a', 1, '$', ['a', '$']),
  PDARule.new(1, 'a', 1, 'a', ['a', 'a']),
  PDARule.new(1, 'a', 1, 'b', ['a', 'b']),
  PDARule.new(1, 'b', 1, '$', ['b', '$']),
  PDARule.new(1, 'b', 1, 'a', ['b', 'a']),
  PDARule.new(1, 'b', 1, 'b', ['b', 'b']),
  PDARule.new(1, nil, 2, '$', ['$']),
  PDARule.new(1, nil, 2, 'a', ['a']),
  PDARule.new(1, nil, 2, 'b', ['b']),
  PDARule.new(2, 'a', 2, 'a', []),
  PDARule.new(2, 'b', 2, 'b', []),
  PDARule.new(2, nil, 3, '$', ['$']),
])

#configuration = PDAConfiguration.new(1, Stack.new(['$']))
#
#npda = NPDA.new(Set[configuration], [3], rulebook)
#
##puts npda.accepting?
##puts npda.current_configurations.inspect
#npda.read_string('abb') #回文じゃない
#puts npda.accepting?
#
##puts npda.current_configurations.inspect
#npda.read_character('a') #回文と言える
#puts npda.accepting?


p '------------------------------'

npda_design = NPDADesign.new(1, '$', [3], rulebook)

p npda_design.accepts?('aba')
p npda_design.accepts?('babbaabbab')
