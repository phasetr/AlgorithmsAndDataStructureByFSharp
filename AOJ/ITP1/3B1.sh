#!/bin/bash
chmod +x 3B1.hs
cat << EOS
RESULT
Case 1: 3
Case 2: 5
Case 3: 11
Case 4: 7
Case 5: 8
Case 6: 19
======
EOS
./3B1.hs < 3B1.txt
