require './number'
require './bool'
require './is_zero'
require './pair'
require './calc'
require './list'

my_list =
  UNSHIFT[
    UNSHIFT[
      UNSHIFT[EMPTY][THREE]
    ][TWO]
][ONE]


p to_integer(FIRST[my_list])
p to_integer(FIRST[REST[my_list]])
p to_integer(FIRST[REST[REST[my_list]]])
p to_boolean(IS_EMPTY[my_list])
p to_boolean(IS_EMPTY[EMPTY])

p to_array(my_list).map{|p| to_integer(p) }

p '-------------------------------'

my_range = RANGE[ONE][FIVE]
p to_array(my_range).map{ |p| to_integer(p) }

p to_integer(FOLD[RANGE[ONE][FIVE]][ZERO][ADD])
p to_integer(FOLD[RANGE[ONE][FIVE]][ONE][MULTIPLY])

my_list = MAP[RANGE[ONE][FIVE]][INCREMENT]
p to_array(my_list).map { |p| to_integer p }
