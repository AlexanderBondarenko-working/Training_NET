using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Task01_1
{
    public class NetworkResourceLinkMaterial : TrainingMaterial
    {
        public Uri Content { get; private set; }
        public LINK_TYPE LinkType { get; private set; }

        public NetworkResourceLinkMaterial(string contentURI, LINK_TYPE linkType)
        {
            LinkType = linkType;
            Content = new Uri(contentURI);
        }

        public override string ToString()
        {
            return "NetworkResourceLinkMaterial: " + Content + " " + LinkType;
        }
    }
}
