struct Card
  suit
  value
  Card(suit, value) = new(suit, value)
end

# スートと値を分ける関数
make_cards(input) = [Card(card[begin], card[end]) for card in input]

# バブルソート
function bubble(input)
  a = make_cards(input)
  N = length(a)
  for i in 1:N
    j = N
    while j > i
      if a[j].value < a[j-1].value
        a[j], a[j-1] = a[j-1], a[j]
      end
      j -= 1
    end
  end
  return a
end

# 選択ソート
function selection(input)
  a = make_cards(input)
  N = length(a)
  for i in 1:N
    minj = i
    for j in i:N
      if a[j].value < a[minj].value
        minj = j
      end
    end
    a[i], a[minj] = a[minj], a[i]
  end
  return a
end

# バブルソートと選択ソートを比べて安定ソートかどうか判定する
is_stable(b,s) = all([b[i].suit == s[i].suit for i in 1:length(b)])
# カードのベクターから出力用文字列を生成する
myprint(cards) = println(join(["$(card.suit)$(card.value)" for card in cards], " "))
# 最終的な結果出力用関数
function solve(input)
  b = bubble(input)
  s = selection(input)

  myprint(b)
  println("Stable")

  myprint(s)
  if is_stable(b,s)
    println("Stable")
  else
    println("Not stable")
  end
end
input = ["H4", "C9", "S4", "D2", "C3"]
solve(input)
