require './pda.rb'

stack = Stack.new(%w{a b c d e})
p stack
p stack.top
p stack.pop.pop.top
p stack.push('x').push('y').top
p stack.push('x').push('y').pop.top
