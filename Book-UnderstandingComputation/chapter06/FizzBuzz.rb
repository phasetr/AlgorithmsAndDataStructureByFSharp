require './number'
require './bool'
require './is_zero'
require './pair'
require './calc'
require './list'
require './string'
require './to_digits'

solution = MAP[RANGE[ONE][HUNDRED]][-> n {
  IF[IS_ZERO[MOD[n][FIFTEEN]]][
    FIZZBUZZ
  ][IF[IS_ZERO[MOD[n][THREE]]][
    FIZZ
  ][IF[IS_ZERO[MOD[n][FIVE]]][
    BUZZ
  ][
    TO_DIGITS[n]
  ]]]
}]

to_array(solution).each do |p|
  puts to_string(p)
end

