#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o code01.out code01.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER"
echo "p2 180"
echo "p5 400"
echo "p1 450"
echo "p3 550"
echo "p4 800"
echo "=================="
echo "RESULT"
./code01.out < sample1.txt
echo "=================="
