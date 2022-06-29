;;; https://atcoder.jp/contests/abc057/tasks/abc057_b
;;; ar44denchi, https://atcoder.jp/contests/abc057/submissions/7355314
(defun f (p q)
  (+ (abs (- (first p) (first q)))
      (abs (- (second p) (second q)))))
(defun solve (n m ab cd)
  (let ((lst3 (loop for e1 across ab
                    collect
                    (loop for e2 across cd
                          collect (f e1 e2)))))
    (loop for i in lst3
          collect (1+ (position (apply #'min i) i)))))
(let* ((n (read))
       (m (read))
       (ab (make-array n :element-type 'uint32))
       (cd (make-array m :element-type 'uint32)))
  (dotimes (i n) (setf (aref ab i) (read)))
  (dotimes (i m) (setf (aref cd i) (read)))
  (format t "~{~A~%~}" (solve n m ab cd)))

(testing "test"
  (ok (equal '(2 1)
             (solve 2 2
                    #((2 0) (0 0)) #((-1 0) (1 0)))))
  (ok (equal '(3 1 2)
             (solve 3 4
                    #((10 10) (-10 -10) (3 3))
                    #((1 2) (2 3) (3 5) (3 5)))))
  (ok (equal '(5 4 3 2 1)
             (solve 5 5
                    #((-100000000 -100000000) (-100000000 100000000) (100000000 -100000000) (100000000 100000000) (0 0))
                    #((0 0) (100000000 100000000) (100000000 -100000000) (-100000000 100000000) (-100000000 -100000000))))))
