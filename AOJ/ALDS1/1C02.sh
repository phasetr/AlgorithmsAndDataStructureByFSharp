#!/bin/bash
chmod +x 1C02.hs
cat << EOS
RESULT 4
======
EOS
./1C02.hs << EOS
6
2
3
4
5
6
7
EOS
