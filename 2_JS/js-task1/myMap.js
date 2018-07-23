const fs=require('fs');
let arr=[1,2,3,4,5];
let arrJson=JSON.parse(fs.readFileSync('./arrayReleases.json', 'utf8'));


//task A map
Array.prototype.map=function(projectionFunction){
    let res=[];
    if(typeof(projectionFunction)==="function"){
        for(let i=0; i< this.length; i ++){
            res.push(projectionFunction.call(this,this[i],i))
        }
    }
    return res;
};
let arr_res= arr.map(function(x){
    return x+1;});
//console.log(arr_res);

//task Б
let arrJson_res=arrJson.map(function(x){
    let obj={
        'id': x.id,
        'title': x.title
    }
    return obj;
});
//console.log(arrJson_res);

//task В filter
 Array.prototype.filter=function (predicateFunction) {
     let res=[];
     if(typeof(predicateFunction)==="function") {
         for (let i = 0; i < this.length; i++) {
             if (predicateFunction.call(this, this[i], i)) {
                 res.push(this[i]);
             }
         }
     }
    return res;
};
arr_res=arr.filter(function(x){
    return x>2
});
//console.log(arr_res);

//task Г
arrJson_res=arrJson.filter(function (x) {
    return x.rating > 4.0;})
.map(function(x){
    return x.id;
});
//console.log(arrJson_res);

//task Д
// let movies=JSON.parse(fs.readFileSync('./movieList.json', 'utf8'));
// let videoList=Array.prototype.concat.apply([],[movies[0].videos,movies[1].videos]);
// let movies2= videoList.map(function(x){
//     let boxart=x.boxarts.filter(function(y){
//         return y.width==150 && y.height==200
//     });
//     let obj={
//         'id': x.id,
//         'title': x.title,
//         'boxart': boxart[0].url
//     }
//     return obj;
// });

let movies=JSON.parse(fs.readFileSync('./movieList.json', 'utf8'));
let videos_in_movie=movies.map(function (movie) {
    let video_res = movie.videos.map(function (video) {
        return video.boxarts.filter(function(boxart){
            return boxart.width==150 && boxart.height==200
        }).map(function (boxart) {
            return {
                'id': video.id,
                'title': video.title,
                'boxart': boxart.url
            }
        })

    });
    return Array.prototype.concat.apply([],video_res);
});
//console.log(Array.prototype.concat.apply([],videos_in_movie));
//
// let videoList=Array.prototype.concat.apply([],[movies[0].videos,movies[1].videos]);
// let movies2= videoList.map(function(x){
//     let boxart=x.boxarts.filter(function(y){
//         return y.width==150 && y.height==200
//     });
//     let obj={
//         'id': x.id,
//         'title': x.title,
//         'boxart': boxart[0].url
//     }
//     return obj;
// });
//console.log(movies2);

//task Д2 reduce
 Array.prototype.reduce=function (combiner,initialValue) {
     let res = initialValue != undefined ? initialValue : null;
     if(typeof(combiner)==="function") {
         for (let i = 0; i < this.length; i++) {
             res = combiner.call(null, res, this[i], i, this);
         }
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
let boxarts = [{
    width: 200,
    height: 200,
    url: "http://cdn-0.nflximg.com/images/2891/Fracture200.jpg"
}, {
    width: 425,
    height: 150,
    url: "http://cdn-0.nflximg.com/images/2891/Fracture425.jpg"
},{
    width: 150,
    height: 200,
    url: "http://cdn-0.nflximg.com/images/2891/Fracture150.jpg"
}, {
    width: 300,
    height: 200,
    url: "http://cdn-0.nflximg.com/images/2891/Fracture300.jpg"
}, ];
let boxarts_res=boxarts.map(function (x) {
    return {
        "area": x.width*x.height,
        "url": x.url
    }
}).reduce(function (memo,item) {
    return memo.area>item.area ? memo : item },{}).url;
//console.log(boxarts_res)

//task З
let videos = [{
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
let videos_res=videos.reduce(function (memo,item){
    memo[item.id] = item.title;
    return memo;
},{});
//console.log(videos_res);