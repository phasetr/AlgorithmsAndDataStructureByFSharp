;; https://atcoder.jp/contests/abc139/tasks/abc139_b
(defun f (a b)
  (ceiling (/ (1- b) (1- a))))

(let ((a (read))
      (b (read)))
  (print (f a b)))

(ok 3 (f 4 10))
(ok 2 (f 8 9))
(ok 1 (f 8 8))

(defun solve2 ()
  "https://atcoder.jp/contests/abc139/submissions/7250549"
  (let* ((a (read))
         (b (read))
         (val 1))
    (loop for i from 0
          do (when (>= val b)
               (println i)
               (return-from solve2))
             (incf val (- a 1)))))
