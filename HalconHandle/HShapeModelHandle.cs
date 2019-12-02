using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace DisplayControlWrapper
{
    public interface I_HShapeModelHandle
    {
        void WriteShapeModel(string savedPath);
    }
   public  class HShapeModelHandle: I_HShapeModelHandle
    {
        HShapeModel shapeModel;
        public HShapeModelHandle(string filePath)
        {
            shapeModel = new HShapeModel(filePath);
        }


        public void WriteShapeModel(string savedPath)
        {
            shapeModel.WriteShapeModel(savedPath);
        }
    }
}
