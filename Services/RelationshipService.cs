using System;
using System.Collections;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Services;

namespace gregslist_api.Services
{
  public class RelationshipService
  {
    private readonly RelationshipRepository _repo;
    private readonly KeepsService _keepsService;

    public RelationshipService(RelationshipRepository repo, KeepsService keepsService)
    {
      _repo = repo;
      _keepsService = keepsService;
    }

    internal DTOFavoriteCar Create(DTOFavoriteCar newFavoriteCar)
    {
      // Car car = _carService.GetById(newFavoriteCar.CarId);
      // newFavoriteCar = _repo.Create(newFavoriteCar);
      // ViewModelCar favoriteCar = new ViewModelCar();
      return _repo.Create(newFavoriteCar);
    }

    internal IEnumerable<VaultKeepViewModel> Get(string userId)
    {
      return _repo.Get(userId);
    }
  }
}