(function extensions(array) {
    'use strict';

    array.prototype.map = function (projectionFunction) {
        let res = [];
        if (typeof(projectionFunction) === "function") {
            for (let i = 0; i < this.length; i++) {
                res.push(projectionFunction.call(this, this[i], i))
            }
        }
        return res;
    };

    array.prototype.filter = function (predicateFunction) {
        let res = [];
        if (typeof(predicateFunction) === "function") {
            for (let i = 0; i < this.length; i++) {
                if (predicateFunction.call(this, this[i], i)) {
                    res.push(this[i]);
                }
            }
        }
        return res;
    };

})(Array);



let movies = [{
        "name": "Instant Queue",
        "videos": [
            {
                "id": 70111470,
                "title": "Die Hard",
                "boxarts": [{
                    "width": 150,
                    "height": 200,
                    "url": "http://cdn-0.nflximg.com/images/2891/DieHard150.jpg"
                }, {
                    "width": 200,
                    "height": 200,
                    "url": "http://cdn-0.nflximg.com/images/2891/DieHard200.jpg"
                }],
                "url": "http://api.netflix.com/catalog/titles/movies/70111470",
                "rating": 4.0,
                "bookmark": []
            },
            {
                "id": 654356453,
                "title": "Bad Boys",
                "boxarts": [{
                    "width": 200,
                    "height": 200,
                    "url": "http://cdn-0.nflximg.com/images/2891/BadBoys200.jpg"
                }, {
                    "width": 150,
                    "height": 200,
                    "url": "http://cdn-0.nflximg.com/images/2891/BadBoys150.jpg"
                }],
                "url": "http://api.netflix.com/catalog/titles/movies/70111470",
                "rating": 5.0,
                "bookmark": [{"id": 432534, "time": 65876586}]
            }]
    },
        {
            "name": "New Releases",
            "videos": [
                {
                    "id": 65432445,
                    "title": "The Chamber",
                    "boxarts": [{
                        "width": 150,
                        "height": 200,
                        "url": "http://cdn-0.nflximg.com/images/2891/TheChamber150.jpg"
                    }, {
                        "width": 200,
                        "height": 200,
                        "url": "http://cdn-0.nflximg.com/images/2891/TheChamber200.jpg"
                    }],
                    "url": "http://api.netflix.com/catalog/titles/movies/70111470",
                    "rating": 4.0,
                    "bookmark": []
                }, {
                    "id": 675465,
                    "title": "Fracture",
                    "boxarts": [{
                        "width": 200,
                        "height": 200,
                        "url": "http://cdn-0.nflximg.com/images/2891/Fracture200.jpg"
                    }, {
                        "width": 150,
                        "height": 200,
                        "url": "http://cdn-0.nflximg.com/images/2891/Fracture150.jpg"
                    }, {
                        "width": 300,
                        "height": 200,
                        "url": "http://cdn-0.nflximg.com/images/2891/Fracture300.jpg"
                    }],
                    "url": "http://api.netflix.com/catalog/titles/movies/70111470",
                    "rating": 5.0,
                    "bookmark": [{"id": 432534, "time": 65876586}]
                }]
        }]

function buildRes(title, id,  boxart) {
    return{
        "title": title,
        "id":id,
        "boxart":boxart }
};

let videos_all=[];
movies.map(function (movie) {
    movie.videos.map(function (video) {
      //  const buildFix=buildRes.bind(null, video.id,video.title);
        const buildFix=(boxart)=> buildRes(video.id,video.title,boxart)
        return  video.boxarts.filter(function(boxart){
            return boxart.width==150 && boxart.height==200
        }).map(function (box) {
            videos_all.push(buildFix(box.url));
        });
    });
});
console.log(videos_all)
