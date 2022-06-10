let cars = ["Saab", "Volvo", "BMW"]

console.log(cars.find(v => v === 'BMW'))

cars[0] = 'Tesla'
console.log({ ...cars })

cars.pop()
console.log({ ...cars })

cars = [...cars, 'Audi']
console.log({ ...cars })

cars = ["Saab", "Volvo", "BMW"]
cars.splice(1, 2)
console.log({ ...cars })