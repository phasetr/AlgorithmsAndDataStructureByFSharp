// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_A/review/1971008/c7c7/C++
#include<iostream>
#include<cstdio>
#include<cstdlib>
#include<cstring>
using namespace std;
int top,s[1000];
int pop(){
  top--;
  return s[top+1];
}
void push(int a){
  s[++top]=a;
}
int main(){
  int b,a;
  top=0;
  char c[3];
  while(cin>>c){
    if(c[0]=='+'){
      a=pop();
      b=pop();
      push(a+b);
    }
    else if(c[0]=='-'){
      a=pop();
      b=pop();
      push(b-a);
    }
    else if(c[0]=='*'){
      a=pop();
      b=pop();
      push(a*b);
    }
    else{
      push(atoi(c));
    }
  }
  cout<<pop()<<endl;
  return 0;
}
