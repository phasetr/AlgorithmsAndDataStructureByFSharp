#!/bin/bash
chmod +x 3C1.hs
cat << EOS
RESULT
2 3
2 2
3 5
======
EOS
./3C1.hs < 3C1.txt
