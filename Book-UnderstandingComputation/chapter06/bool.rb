def to_boolean(proc)
  IF[proc][true][false]
end

# TRUE/FALSEだと定義済みとしてエラーが出てしまう
T = -> x { -> y { x } }
F = -> x { -> y { y } }

IF = -> b { b }

