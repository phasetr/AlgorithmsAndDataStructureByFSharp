#|
TODO
https://atcoder.jp/contests/abc107/submissions/3082096
* 1 \leq H, W \leq 100
* a_{i, j} は . または # である。
* マス目全体で少なくともひとつは黒いマスが存在する。
|#
(defun black-rows (h aa)
  (apply #'vector
         (loop for i from 0 to (1- h)
               collect
               (if (find #\# (aref aa i))
                   t nil))))
(defun black-columns (h w aa)
  (apply #'vector
         (loop for i from 0 to (1- w)
               collect
               (if (> (loop for j from 0 to (1- h)
                            count
                            (char= #\# (aref (aref aa j) i))))
                   t nil))))
(defun solve (h w aa)
  (let* ((b-rowa (black-rows h aa))
         (b-cola (black-columns h w aa)))
    (loop for i from 0 to (1- h) collect
      (loop for j from 0 to (1- w)
            collect
            (when (and (aref b-rowa i) (aref b-cola j))
              (aref (aref aa i) j))))))

(let* ((h (read))
       (w (read))
       (aa (apply #'vector(loop for i from 1 to h collect (read-line)))))
  (solve h w aa))

(testing "test"
  (ok (equal ("###" "###" ".##")
             (solve 4 4 #("##.#" "...." "##.#" ".#.#")))))
