﻿using System;
using System.Xml.Serialization;

namespace MyShelf.API.XML
{
    [XmlRoot(ElementName = "Request")]
    public class Request
    {
        [XmlElement(ElementName = "authentication")]
        public String Authentication;

        [XmlElement(ElementName = "key")]
        public String Key;

        [XmlElement(ElementName = "method")]
        public String Method;
    }
}
