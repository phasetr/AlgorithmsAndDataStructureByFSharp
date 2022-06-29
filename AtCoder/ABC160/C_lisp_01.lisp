;; https://atcoder.jp/contests/abc160/tasks/abc160_c
;; 計算すべきは「円弧の小さい方」.
;; 「あるiからの逆回転」は「i+1からの順回転」だから順回転だけ見ればよい.
;; 家0からの経路はスタート位置を経由しないので別途計算
(defun round-dist-at-i (i k n xs)
  (if (eq i 0)
      ;; 単純に入力の最初と最後の差を取ればいい
      (- (aref xs (1- n)) (aref xs 0))
      ;; 一周分の計算をする
      ;; 最後の要素は xs[i-1]+k
      (let* ((dec-i (1- i))
             (mod-dec-i (mod dec-i n)))
        (- (+ (aref xs mod-dec-i) k) (aref xs i)))))
(defun solve (k n xs)
  (reduce
   #'min
   (mapcar #'(lambda (i) (round-dist-at-i i k n xs))
           (loop for i below n collect i))))
(let* ((k (read))
       (n (read))
       (xs (apply #'vector (loop :repeat n :collect (read)))))
  (print (solve k n xs)))

(testing "check"
  (ok (eq (min 1 2) 1))
  (ok (eq (apply #'min '(1 2)) 1))
  (ok (equal (apply #'vector (loop for i below 3 collect i)) #(0 1 2)))
  (ok (eq (mod 6 5) 1))
  (ok (eq (aref #(1 2) 0) 1))
  (ok (eq (aref #(1 2) 1) 2))
  (ok (eq (round-dist-at-i 0 20 3 #(5 10 15)) 10))
  (ok (eq (solve 20 3 #(5 10 15)) 10)))
