def to_integer(proc)
  proc[-> n { n + 1 }][0]
end

ZERO  = -> p { -> x {       x    } }
ONE   = -> p { -> x {     p[x]   } }
TWO   = -> p { -> x {   p[p[x]]  } }
THREE = -> p { -> x { p[p[p[x]]] } }

FIVE = -> p { -> x { p[p[p[p[p[x]]]]] } }
FIFTEEN = -> p { -> x {
  p[p[p[p[p[ p[p[p[p[p[
  p[p[p[p[p[
    x
  ]]]]] ]]]]]
  ]]]]] } }

HUNDRED = -> p { -> x {
  p[p[p[p[p[ p[p[p[p[p[
  p[p[p[p[p[ p[p[p[p[p[
  p[p[p[p[p[ p[p[p[p[p[
  p[p[p[p[p[ p[p[p[p[p[
  p[p[p[p[p[ p[p[p[p[p[

  p[p[p[p[p[ p[p[p[p[p[
  p[p[p[p[p[ p[p[p[p[p[
  p[p[p[p[p[ p[p[p[p[p[
  p[p[p[p[p[ p[p[p[p[p[
  p[p[p[p[p[ p[p[p[p[p[
    x
  ]]]]]]]]]]]]]]]]]]]]
  ]]]]]]]]]]]]]]]]]]]]
  ]]]]]]]]]]]]]]]]]]]]
  ]]]]]]]]]]]]]]]]]]]]
  ]]]]]]]]]]]]]]]]]]]] } }

