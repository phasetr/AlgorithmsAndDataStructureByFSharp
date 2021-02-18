require './REGEXP'

class NFADesign
  def to_nfa(current_states = Set[start_state])
    NFA.new(current_states, accept_states, rulebook)
  end
end

class NFASimulation < Struct.new(:nfa_design)
  def next_state(state, character)
    nfa_design.to_nfa(state).tap {|nfa|
      nfa.read_character(character)
    }.current_states
  end
end

class NFARulebook
  def alphabet
    rules.map(&:character).compact.uniq
  end
end

class NFASimulation
  def rules_for(state)
    nfa_design.rulebook.alphabet.map { |character|
      FARule.new(state, character, next_state(state, character))
    }
  end
end

class NFASimulation
  def discover_states_and_rules(states)
    rules = states.flat_map { |state| rules_for(state) }
    more_states = rules.map(&:follow).to_set

    if more_states.subset?(states)
      [states, rules]
    else
      discover_states_and_rules(states + more_states)
    end
  end
end

class NFASimulation
  def to_dfa_design
    start_state = nfa_design.to_nfa.current_states
    states, rules = discover_states_and_rules(Set[start_state])
    accept_states = states.select { |state| nfa_design.to_nfa(state).accepting? }

    DFADesign.new(start_state, accept_states, DFARulebook.new(rules))
  end
end


