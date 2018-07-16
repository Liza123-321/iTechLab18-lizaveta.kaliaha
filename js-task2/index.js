var Robot = function (name) {
    this.name = name;
}

function add (op1, op2) {
    this.name = this.name || "Human";
    return  this.name + " can count to " + (op1 + op2);
}

var voltron = new Robot("Voltron");

//1
console.log(add(1,0)); // || "Human";

//2
console.log(add.call(voltron,1,2)); //call

//3
console.log(add.apply(voltron,[20,30])); //apply

//4
 console.log(add.bind(voltron)("drinking","beer")); //bind

 //5 Написанный вами код должен вывести console.log имени которое лежит в this.name пятью разными способами
