#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o code00.out code00.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER"
echo "0.00000000 0.00000000"
cat << EOS
33.33333333 0.00000000
50.00000000 28.86751346
66.66666667 0.00000000
100.00000000 0.00000000
EOS
echo "=================="
echo "RESULT"
./code00.out < sample1.txt
echo "=================="
