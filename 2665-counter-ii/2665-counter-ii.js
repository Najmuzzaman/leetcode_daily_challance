/**
 * @param {integer} init
 * @return { increment: Function, decrement: Function, reset: Function }
 */
var createCounter = function(init) {
    let inc=init;
    return  {
        increment: () => {
                inc++;
                return inc;
        },
        reset: () => {
                inc=init;
                return inc;
        },
        decrement: () => {
                inc--;
                return inc;
        }
    }
};

/**
 * const counter = createCounter(5)
 * counter.increment(); // 6
 * counter.reset(); // 5
 * counter.decrement(); // 4
 */