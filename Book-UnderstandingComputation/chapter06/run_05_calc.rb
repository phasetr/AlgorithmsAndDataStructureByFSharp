require './number'
require './bool'
require './is_zero'
require './pair'
require './calc'

# 3 % 2 -> 1
p to_integer(MOD[THREE][TWO])

# (3^3) % (3+2)
# = 27 % 5
# = 2
p to_integer(MOD[
    POWER[THREE][THREE]
  ][
    ADD[THREE][TWO]
  ])
