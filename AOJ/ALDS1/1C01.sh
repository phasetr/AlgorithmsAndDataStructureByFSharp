#!/bin/bash
chmod +x 1C01.hs
cat << EOS
RESULT 4
======
EOS
./1C01.hs << EOS
6
2
3
4
5
6
7
EOS
