using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class CargoManagementSystemTests
{
    [Test]
    public void Test_Constructor_CheckInitialEmptyCargoCollectionAndCount()
    {
       
        var cargoManagementSystem = new CargoManagementSystem();

        
        Assert.AreEqual(0, cargoManagementSystem.CargoCount);
        Assert.IsEmpty(cargoManagementSystem.GetAllCargos());
    }

    [Test]
    public void Test_AddCargo_ValidCargoName_AddNewCargo()
    {
       
        var cargoManagementSystem = new CargoManagementSystem();
        string cargo = "Box of Electronics";

       
        cargoManagementSystem.AddCargo(cargo);

       
        Assert.AreEqual(1, cargoManagementSystem.CargoCount);
        CollectionAssert.Contains(cargoManagementSystem.GetAllCargos(), cargo);
    }

    [Test]
    public void Test_AddCargo_NullOrEmptyCargoName_ThrowsArgumentException()
    {
     
        var cargoManagementSystem = new CargoManagementSystem();

       
        Assert.Throws<ArgumentException>(() => cargoManagementSystem.AddCargo(null));
        Assert.Throws<ArgumentException>(() => cargoManagementSystem.AddCargo(string.Empty));
        Assert.Throws<ArgumentException>(() => cargoManagementSystem.AddCargo("   "));
    }

    [Test]
    public void Test_RemoveCargo_ValidCargoName_RemoveFirstCargoName()
    {
      
        var cargoManagementSystem = new CargoManagementSystem();
        string cargo = "Box of Electronics";
        cargoManagementSystem.AddCargo(cargo);

        
        cargoManagementSystem.RemoveCargo(cargo);

        
        Assert.AreEqual(0, cargoManagementSystem.CargoCount);
        CollectionAssert.DoesNotContain(cargoManagementSystem.GetAllCargos(), cargo);
    }

    [Test]
    public void Test_RemoveCargo_CargoNotFound_ThrowsArgumentException()
    {
        
        var cargoManagementSystem = new CargoManagementSystem();
        string cargo = "Box of Electronics";

        
        Assert.Throws<ArgumentException>(() => cargoManagementSystem.RemoveCargo(cargo));
    }

    [Test]
    public void Test_GetAllCargos_AddedAndRemovedCargos_ReturnsExpectedCargoCollection()
    {
        
        var cargoManagementSystem = new CargoManagementSystem();
        string cargo1 = "Box of Electronics";
        string cargo2 = "Container of Furniture";
        cargoManagementSystem.AddCargo(cargo1);
        cargoManagementSystem.AddCargo(cargo2);

        
        cargoManagementSystem.RemoveCargo(cargo1);
        var cargos = cargoManagementSystem.GetAllCargos();

       
        Assert.AreEqual(1, cargos.Count);
        CollectionAssert.Contains(cargos, cargo2);
        CollectionAssert.DoesNotContain(cargos, cargo1);
    }
}