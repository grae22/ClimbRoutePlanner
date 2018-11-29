using CRP.Entities;
using CRP.Logic;

namespace CRP
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var simulation = new ClimbSimulation();
      var gearAssignmentRegistry = new GearAssignmentRegistry();
      var climber1 = new GearCarrier(0, "Climber1", gearAssignmentRegistry);
      var climber2 = new GearCarrier(1, "Climber2", gearAssignmentRegistry);
      var draw1 = new GearItem(0, "Draw1");
      var draw2 = new GearItem(1, "Draw2");
      var draw3 = new GearItem(2, "Draw3");
      var draw4 = new GearItem(3, "Draw4");
      var draw5 = new GearItem(4, "Draw5");
      var ground = new Location(0, "Ground");
      var pitch1 = new Location(1, "Pitch1");
      var stance1 = new Location(2, "Stance1");
      var pitch2 = new Location(3, "Pitch2");
      var stance2 = new Location(4, "Stance2");
      var boltsPitch1 = new GearCarrier(10, "BoltsPitch1", gearAssignmentRegistry);
      var boltsPitch2 = new GearCarrier(11, "BoltsPitch2", gearAssignmentRegistry);
      var anchorsStance1 = new GearCarrier(20, "AnchorsPitch1", gearAssignmentRegistry);
      var anchorsStance2 = new GearCarrier(21, "AnchorsPitch2", gearAssignmentRegistry);
      
      climber1.ChangeLocation(ground);
      climber2.ChangeLocation(ground);

      boltsPitch1.ChangeLocation(pitch1);
      boltsPitch2.ChangeLocation(pitch2);

      anchorsStance1.ChangeLocation(stance1);
      anchorsStance2.ChangeLocation(stance2);

      climber1.AssignItem(draw1);
      climber1.AssignItem(draw2);
      climber1.AssignItem(draw3);
      climber1.AssignItem(draw4);
      climber1.AssignItem(draw5);

      simulation.AddClimber(climber1);
      simulation.AddClimber(climber2);

      climber1.ChangeLocation(pitch1);
      climber1.TransferItem(draw1, boltsPitch1);
      climber1.TransferItem(draw2, boltsPitch1);
      climber1.TransferItem(draw3, boltsPitch1);

      climber1.ChangeLocation(stance1);
      climber1.TransferItem(draw4, anchorsStance1);
      climber1.TransferItem(draw5, anchorsStance1);

      climber2.ChangeLocation(pitch1);
      boltsPitch1.TransferItem(draw1, climber2);
      boltsPitch1.TransferItem(draw2, climber2);
      boltsPitch1.TransferItem(draw3, climber2);

      climber2.ChangeLocation(stance1);
      anchorsStance1.TransferItem(draw4, climber2);
      anchorsStance1.TransferItem(draw5, climber2);

      climber2.ChangeLocation(pitch2);
      climber2.TransferItem(draw1, boltsPitch2);
      climber2.TransferItem(draw2, boltsPitch2);
      climber2.TransferItem(draw3, boltsPitch2);

      climber2.ChangeLocation(stance2);
      climber2.TransferItem(draw4, anchorsStance2);
      climber2.TransferItem(draw5, anchorsStance2);

      climber1.ChangeLocation(pitch2);
      boltsPitch2.TransferItem(draw1, climber1);
      boltsPitch2.TransferItem(draw2, climber1);
      boltsPitch2.TransferItem(draw3, climber1);

      climber1.ChangeLocation(stance2);
      anchorsStance2.TransferItem(draw4, climber2);
      anchorsStance2.TransferItem(draw5, climber2);
    }
  }
}
