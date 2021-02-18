require './number'
require './bool'
require './is_zero'
require './pair'
require './calc'
require './list'
require './string'
require './to_digits'

p to_array(TO_DIGITS[FIVE]).map { |p| to_integer(p) }
p to_array(TO_DIGITS[POWER[FIVE][THREE]]).map {|p| to_integer(p) }
