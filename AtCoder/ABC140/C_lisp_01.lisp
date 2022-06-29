"https://atcoder.jp/contests/abc140/tasks/abc140_c
問題文
長さ N の値の分からない整数列 A があります。
長さ N−1 の整数列 B が与えられます。
このとき、
B_i≥max(A_i,A_{i+1})
が成立することが分かっています。
A の要素の総和として考えられる値の最大値を求めてください。

制約
入力は全て整数
2≤N≤100
0≤B_i≤10^5"
(defun solve (n bs)
  (apply #'+
         (reduce (lambda (x y)
                   (list y (+ (cadr x) (min (car x) y))))
                 bs
                 :initial-value (list (car bs) 0))))
(let* ((n (read))
       (bs (loop :repeat n :collect (read))))
  (princ (solve n bs)))
(testing "test"
  (ok (= (solve 3 '(2 5)) 9))
  (ok (= (solve 2 '(3)) 6))
  (ok (= (solve 6 '(0 153 10 10 23)) 53)))
