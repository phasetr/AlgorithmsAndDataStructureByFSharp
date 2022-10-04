// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_2_B/review/6092185/neguse_atama/C++
#include<iostream>
#include<boost/multiprecision/cpp_int.hpp>
using namespace std;
int main(void){
  boost::multiprecision::cpp_int a,b;
  cin>>a>>b;
  cout<<a-b<<endl;
  return 0;
}
