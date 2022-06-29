"https://atcoder.jp/contests/abc148/tasks/abc148_d
N 個のレンガが横一列に並んでいます。

左から i (1≤i≤N) 番目のレンガには、整数 ai が書かれています。
あなたはこのうち N−1 個以下の任意のレンガを選んで砕くことができます。
その結果、K 個のレンガが残っているとします。
このとき、任意の整数 i (1≤i≤K) について、
残っているレンガの中で左から i 番目のものに書かれた整数が i であるとき、
すぬけさんは満足します。

すぬけさんが満足するために砕く必要のあるレンガの最小個数を出力してください。
もし、どのように砕いてもそれが不可能な場合、代わりに -1 を出力してください。

制約
入力は全て整数である。
1≤N≤200000
1≤ai≤N"

"左から1,2,3を順に拾っていけばよく,
これをnumとして積む.
numに一致しない場合はaccを+1して積んでいく.
numが初期値のままならどう砕いても不可能."
(defun f (old new)
  (let ((num (car old))
        (acc (cadr old)))
    (if (eq new (1+ num))
        (list new acc)
        (list num (1+ acc)))))
(defun solve (n as)
  (let* ((res (reduce #'f as :initial-value '(0 0)))
         (num (car res))
         (acc (cadr res)))
    (if (eq num 0)
        -1
        acc)))
(let* ((n (read))
       (xs (loop :repeat n :collect (read))))
  (format t "~a" (solve n xs)))

(testing "test"
  (ok (= (solve 3 '(2 1 2)) 1))
  (ok (= (solve 3 '(2 2 2)) -1))
  (ok (= (solve 10 '(3 1 4 1 5 9 2 6 5 3)) 7))
  (ok (= (solve 1 '(1)) 0)))
