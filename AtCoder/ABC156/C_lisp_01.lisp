;;; https://atcoder.jp/contests/abc156/tasks/abc156_c
(defun solve1 (lst)
  (loop
    :for p
    :from 0 :to 100
    :minimize
    (loop :for i :in lst :sum (expt (- p i) 2))))
(ok (solve1 '(1 4)) 5)
(ok (solve1 '(14 14 2 13 56 2 37)) 2354)

(defun solve2 (xs)
  (loop for y from 0 to 100
        minimize (loop for x in xs
                       sum (expt (- x y) 2))))
(ok (solve2 '(1 4)) 5)
(ok (solve2 '(14 14 2 13 56 2 37)) 2354)

(defun solve3 (xi)
  (let* ((n (length xi))
         (ave-xi (/ (apply #'+ xi) n))
         (p (floor (+ ave-xi (/ 1 2)))))
    (reduce #'(lambda (x y)
                (+ x (expt (- y p) 2)))
            xi :initial-value 0)))
(ok (solve3 '(1 4)) 5)
(ok (solve3 '(14 14 2 13 56 2 37)) 2354)

(defun solve4 (xs)
  "min(sum((x - p) ** 2 for x in xs) for p in range(1, 101))"
  (loop for p from 1 to 100
        minimize
        (reduce #'+ (mapcar #'(lambda (x) (expt (- x p) 2)) xs))))
(ok (solve4 '(1 4)) 5)
(ok (solve4 '(14 14 2 13 56 2 37)) 2354)

(defun solve5 (n xs)
  (flet ((average (n &rest numbers)
           (/ (reduce #'+ numbers) n)))
    (let* ((p (round (apply #'average n xs))))
      (loop for x in xs
            sum (expt (- x p) 2)))))
(ok (solve5 2 '(1 4)) 5)
(ok (solve5 7 '(14 14 2 13 56 2 37)) 2354)

(defun solve6 (m)
  (loop
    :for k
    :from 1
    :upto 100
    :minimize
    (reduce #'+ (mapcar (lambda (x) (expt (- x k) 2)) m))))
(ok (solve6 '(1 4)) 5)
(ok (solve6 '(14 14 2 13 56 2 37)) 2354)

;;;
(let* ((n (read))
       (lst (loop :repeat n :collect (read))))
  (print (solve1 lst)))
