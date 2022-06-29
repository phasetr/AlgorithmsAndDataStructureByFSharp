"https://atcoder.jp/contests/abc139/tasks/abc139_c
左右一列に N 個のマスが並んでいます。

左から i 番目のマスの高さは Hi です。
あなたは好きなマスに降り立ち、
右隣のマスの高さが今居るマスの高さ以下である限り右隣のマスへ移動し続けます。
最大で何回移動できるでしょうか。

制約
入力は全て整数である。
1≤N≤10^5
1≤Hi≤10^9"

(defun f (xs y)
  (destructuring-bind (x tmp acc) xs
    (if (>= x y)
        (list y (1+ tmp) (max (1+ tmp) acc))
        (list y 0 (max tmp acc)))))
(defun solve (N Hs)
  (let ((res (reduce #'f Hs :initial-value '(0 0 0))))
    (caddr res)))

(let* ((n (read))
       (hs (loop :repeat n :collect (read))))
  (format t "~a" (solve n hs)))

(testing "test"
  (ok (= (solve 5 '(10 4 8 7 3)) 2))
  (ok (= (solve 7 '(4 4 5 6 6 5 5)) 3))
  (ok (= (solve 4 '(1 2 3 4)) 0)))
