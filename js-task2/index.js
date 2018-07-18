var Robot = function (name) {
    this.name = name;
};

function add(op1, op2) {
    this.name = this.name || "Human";
    return this.name + " can count to " + (op1 + op2);
}
var voltron = new Robot("Voltron");

(function task_2(console,add,voltron) {
    'use strict';

    //1
    console.log(add(1, 0)); // || "Human";

    //2
    console.log(add.call(voltron, 1, 2)); //call

    //3
    console.log(add.apply(voltron, [20, 30])); //apply

    //4
    console.log(add.bind(voltron)("drinking", "beer"))

})(console, add,voltron);

// #5 Написанный вами код должен вывести в консоль "Voltron" внутри setTimeout, 5-ью разными способами
(function (){
    'use strict';

    function show() {
        this.name = this.name || "42";
        return this.name;
    }

    setTimeout(()=>{
     console.log(this.name);
     console.log(voltron.name);
     console.log(show.call(voltron));
     console.log(show.apply(voltron));
     console.log(show.bind(voltron)());
    }, 1000);

}.bind(voltron))();