// https://onlinejudge.u-aizu.ac.jp/solutions/problem/GRL_1_A/review/2490318/Yoshimura/JavaScript
function PriorityQueue( comp ){
  this.list = [];
  this.comp = comp;
}

PriorityQueue.prototype.enq = function( x ){
  this.list.push( x );
  var i = this.list.length-1;

  while( i > 0 ){
    var p = Math.floor((i-1)/2);

    if( this.comp( this.list[p], x ) <= 0 )
      break;

    this.list[i] = this.list[p];
    i = p;
  }

  if( this.list.length > 0 )
    this.list[i] = x;
};

PriorityQueue.prototype.deq = function() {
  var min = this.peek();
  var root = this.list[this.list.length-1];
  this.list.splice( this.list.length-1, 1 );

  var i = 0;

  while( i*2+1 < this.list.length )
  {
    var a = i*2+1, b = i*2+2, c = b < this.list.length && this.comp(this.list[b], this.list[a]) < 0 ? b : a;

    if( this.comp( this.list[c], root ) >= 0 )
      break;

    this.list[i] = this.list[c];
    i = c;
  }

  if( this.list.length > 0 )
    this.list[i] = root;

  return min;
};

PriorityQueue.prototype.peek = function() {
  return this.list.length == 0 ? undefined : this.list[0];
};

PriorityQueue.prototype.size = function() {
  return this.list.length;
};

PriorityQueue.prototype.isEmpty = function() {
  return this.size() == 0;
};

const MAX_V = 100000;
const INF = Number.POSITIVE_INFINITY/4;
var V, E, r;
var G;
var d;

function dijkstra( s )
{
  var pque = new PriorityQueue(function(a,b) {
    if( a.dist != b.dist )
      return a.dist-b.dist;

    return a.v-b.v;
  });
  d[s] = 0;
  pque.enq( { dist: 0, v: s } );

  while( !pque.isEmpty() )
  {
    var p = pque.deq();

    if( d[p.v] < p.dist )
      continue;

    for( var i = 0; i < G[p.v].length; ++i )
    {
      var e = G[p.v][i];

      if( d[e.to] > d[p.v] + e.cost )
      {
        d[e.to] = d[p.v] + e.cost;
        pque.enq( { dist: d[e.to], v: e.to } );
      }
    }
  }
}

(function main( input )
 {
   var lines = input.trim().split('\n');
   var fst = true;

   for( var j = 0; j < lines.length; ++j )
   {
     if( lines[j] == '' )
       break;

     var words = lines[j].trim().split(' ').map(Number);

     if( fst )
     {
       V = words[0];
       E = words[1];
       r = words[2];

       G = [];
       d = [];

       for( var i = 0; i < V; ++i )
         G[i] = [], d[i] = INF;
     }
     else
       G[words[0]].push( { to: words[1], cost: words[2] } );

     fst = false;
   }

   dijkstra( r );

   d.forEach( function(v) { console.log( v == INF ? "INF" : v ); } );
 })( require('fs').readFileSync( '/dev/stdin', 'utf8' ) );
