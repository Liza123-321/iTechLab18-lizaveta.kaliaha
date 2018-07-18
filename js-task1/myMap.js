const fs=require('fs');
let arr=[1,2,3,4,5];
let arrJson=JSON.parse(fs.readFileSync('./arrayReleases.json', 'utf8'));


//task A map
Array.prototype.map=function(projectionFunction){
    let res=[];
    for(let i=0; i< this.length; i ++){
        res.push(projectionFunction.call(this,this[i],i))
    }
    return res;
};
let arr2= arr.map(function(x){
    return x+1;});
//console.log(arr2);

//task Б
let arrJson2=arrJson.map(function(x){
    let obj={
        'id': x.id,
        'title': x.title
    }
    return obj;
});
//console.log(arrJson2);

//task В filter
 Array.prototype.filter=function (predicateFunction) {
     let res=[];
    for(let i=0;i<this.length;i++){
    if(predicateFunction.call(this,this[i],i)){
        res.push(this[i]);
        }
    }
return res;
};
arr2=arr.filter(function(x){
    return x>2
});
//console.log(arr2);

//task Г
arrJson2=arrJson.filter(function (x) {
    return x.rating > 4.0;})
.map(function(x){
    return x.id;
});
//console.log(arrJson2);

//task Д

let movies=JSON.parse(fs.readFileSync('./movieList.json', 'utf8'));
let videoList=Array.prototype.concat.apply([],[movies[0].videos,movies[1].videos]);
let movies2= videoList.map(function(x){
    let boxart=x.boxarts.filter(function(y){
        return y.width==150 && y.height==200
    });
    let obj={
        'id': x.id,
        'title': x.title,
        'boxart': boxart[0].url
    }
    return obj;
});
//console.log(movies2);

//task Д2 reduce
 Array.prototype.reduce=function (combiner,initialValue) {
     let res=initialValue != undefined? initialValue : null;
     for(let i=0;i < this.length;i++){
         res= combiner.call(null,res,this[i],i,this);
     }
    return res;
 };

//  console.log([1,2,3].reduce(function (memo,item) {
//     return memo+item;
// }));
// console.log([1,2,3].reduce(function (memo,item) {
//     return memo+item;
// },10));

//task  E
let ratings=[2,3,1,4,5];
// console.log(ratings.reduce(function(memo,item){
//  return (memo>item ? memo : item);
// }));

//task Ж
var boxarts = [{
    width: 200,
    height: 200,
    url: "http://cdn-0.nflximg.com/images/2891/Fracture200.jpg"
}, {
    width: 150,
    height: 200,
    url: "http://cdn-0.nflximg.com/images/2891/Fracture150.jpg"
}, {
    width: 300,
    height: 200,
    url: "http://cdn-0.nflximg.com/images/2891/Fracture300.jpg"
}, {
    width: 425,
    height: 150,
    url: "http://cdn-0.nflximg.com/images/2891/Fracture425.jpg"
}];
let boxarts2=boxarts.map(function (x) {
    return {
        "area": x.width*x.height,
        "url": x.url
    }
}).reduce(function (memo,item) {
    return memo.area>item.area ? memo.url : item.url },{});
console.log(boxarts2)

//task З
var videos = [{
    "id": 65432445,
    "title": "The Chamber"
}, {
    "id": 675465,
    "title": "Fracture"
}, {
    "id": 70111470,
    "title": "Die Hard"
}, {
    "id": 654356453,
    "title": "Bad Boys"
}];
let videos2=videos.reduce(function (memo,item){
    memo[item.id] = item.title;
    return memo;
},{});
//console.log(videos2);