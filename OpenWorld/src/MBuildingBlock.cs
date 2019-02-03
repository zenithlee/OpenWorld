using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWorld
{
  public class MBuildingBlock
  {
    private string name = "Block";
    private string textureID = "TEXTURE01";
    private string materialID = "MATERIAL01";
    private string templateID;
    private string type = "MModel";
    private double[] size = new double[] { 1, 1, 1 };
    private string model;
    private double weight = 1;

    public string Name { get => name; set => name = value; }    
    public string TemplateID { get => templateID; set => templateID = value; }
    public string Type { get => type; set => type = value; }
    public string TextureID { get => textureID; set => textureID = value; }
    public double[] Size { get => size; set => size = value; }
    public string Model { get => model; set => model = value; }
    public double Weight { get => weight; set => weight = value; }
    public string MaterialID { get => materialID; set => materialID = value; }
  }
}
