#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o lower_bound.out lower_bound.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER"
echo "A[5] = 4"
echo "A[2] = 2"
echo "=================="
echo "RESULT"
./lower_bound.out
echo "=================="
