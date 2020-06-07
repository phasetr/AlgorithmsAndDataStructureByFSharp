#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o code01.out code01.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER"
echo "3"
echo "=================="
echo "RESULT"
./code01.out < sample1.txt
echo "=================="
