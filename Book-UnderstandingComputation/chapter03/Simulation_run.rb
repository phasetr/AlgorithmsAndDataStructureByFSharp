require './Simulation.rb'

rulebook = NFARulebook.new([
  FARule.new(1, 'a', 1), FARule.new(1, 'a', 2), FARule.new(1, nil, 2),
  FARule.new(2, 'b', 3),
  FARule.new(3, 'b', 1), FARule.new(3, nil, 2)
])

nfa_design = NFADesign.new(1, [3], rulebook)

p nfa_design.to_nfa.current_states

p nfa_design.to_nfa(Set[2]).current_states

p nfa_design.to_nfa(Set[3]).current_states

nfa = nfa_design.to_nfa(Set[2, 3])
p nfa

nfa.read_character('b')
p nfa.current_states

p '------------ Simulation --------------'
simulation = NFASimulation.new(nfa_design)
p simulation.next_state(Set[1, 2], 'a')
p simulation.next_state(Set[1, 2], 'b')
p simulation.next_state(Set[3, 2], 'b')
p simulation.next_state(Set[1, 3, 2], 'b')
p simulation.next_state(Set[1, 3, 2], 'a')


p rulebook.alphabet
p simulation.rules_for(Set[1, 2])
p simulation.rules_for(Set[3, 2])

start_state = nfa_design.to_nfa.current_states

p simulation.discover_states_and_rules(Set[start_state])


p '------------trans--------------'

dfa_design = simulation.to_dfa_design
p dfa_design

p dfa_design.accepts?('aaa')
p dfa_design.accepts?('aab')
p dfa_design.accepts?('bbbabb')
