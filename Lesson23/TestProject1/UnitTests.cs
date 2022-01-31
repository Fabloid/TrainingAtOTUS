using PrototypeApp.Models;
using System;
using Xunit;

namespace PrototypeTests {
    public class UnitTests {
        private Car _car = new Car {
            Model = "BMW",
            Motor = 150,
            CountDoors = 4
        };

        private Motorbike _motorbike = new Motorbike {
            Model = "Suzuki",
            Motor = 100,
            CountWheels = 2
        };


        [Fact]
        public void CarCopyTest() {
            var newCar = _car.Copy();
            Assert.Equal(newCar, _car);
        }

        [Fact]
        public void CarCopyReferenceTest() {
            var newCar = _car.Copy();
            Assert.NotSame(newCar, _car);
        }

        [Fact]
        public void CarCloneTest() {
            var newCar = _car.Copy();
            Assert.Equal(newCar, _car);
        }

        [Fact]
        public void MotorbikeCopyTest() {
            var newMotorbike = _motorbike.Copy();
            Assert.Equal(newMotorbike, _motorbike);
        }

        [Fact]
        public void MotorbikeCopyReferenceTest() {
            var newMotorbike = _motorbike.Copy();
            Assert.NotSame(newMotorbike, _motorbike);
        }

        [Fact]
        public void MotorbikeCloneTest() {
            var newMotorbike = _motorbike.Clone();
            Assert.Equal(newMotorbike, _motorbike);
        }
    }
}
