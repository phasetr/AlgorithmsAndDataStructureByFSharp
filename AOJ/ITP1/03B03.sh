#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o 3B03.out 3B03.cpp
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
./3B03.out < 3B03.txt
