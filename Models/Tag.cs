using SeguridadInformática.Enums;
using System;
namespace SeguridadInformática.Models
{
    public class Tag
    {
        public TagEquipamientoAuxiliar EquipamientoAuxiliar { get; set; }
        public TagEquiposInformaticos EquiposInformaticos { get; set; }
        public TagInstalaciones Instalaciones { get; set; }
        public TagPersonal Personal { get; set; }
        public TagRedesDeComunicaciones RedesDeComunicaciones { get; set; }
        public TagServicios Servicios { get; set; }
        public TagSoftware Software { get; set; }

        public TagsType TipoDeTag { get; set; }

        public Tag()
        {
        }

        public string ReturnTypeOfTag()
        {
            if (EquipamientoAuxiliar != null)
            {
                return "EquipamientoAuxiliar";
            }
            else if (EquiposInformaticos != null)
            {
                return "EquiposInformaticos";
            }
            else if (Instalaciones != null)
            {
                return "Instalaciones";
            }
            else if (Personal != null)
            {
                return "Personal";
            }
            else if (RedesDeComunicaciones != null)
            {
                return "RedesDeComunicaciones";
            }
            else if (Servicios != null)
            {
                return "Servicios";
            }
            else if (Software != null)
            {
                return "Software";
            }

            return null;
        }

        public void SetTag(string typeTag, string tag)
        {
            TipoDeTag = (TagsType)Enum.Parse(typeof(TagsType), typeTag);

            // Asumiendo que cada uno de estos es un enum en C#
            switch (typeTag)
            {
                case "EquipamientoAuxiliar":
                    EquipamientoAuxiliar = (TagEquipamientoAuxiliar)Enum.Parse(typeof(TagEquipamientoAuxiliar), tag);
                    break;
                case "EquiposInformaticos":
                    EquiposInformaticos = (TagEquiposInformaticos)Enum.Parse(typeof(TagEquiposInformaticos), tag);
                    break;
                case "Instalaciones":
                    Instalaciones = (TagInstalaciones)Enum.Parse(typeof(TagInstalaciones), tag);
                    break;
                case "Personal":
                    Personal = (TagPersonal)Enum.Parse(typeof(TagPersonal), tag);
                    break;
                case "RedesDeComunicaciones":
                    RedesDeComunicaciones = (TagRedesDeComunicaciones)Enum.Parse(typeof(TagRedesDeComunicaciones), tag);
                    break;
                case "Servicios":
                    Servicios = (TagServicios)Enum.Parse(typeof(TagServicios), tag);
                    break;
                case "Software":
                    Software = (TagSoftware)Enum.Parse(typeof(TagSoftware), tag);
                    break;
            }
        }

        public string GetTag()
        {
            if (EquipamientoAuxiliar != null)
            {
                return EquipamientoAuxiliar.ToString();
            }
            else if (EquiposInformaticos != null)
            {
                return EquiposInformaticos.ToString();
            }
            else if (Instalaciones != null)
            {
                return Instalaciones.ToString();
            }
            else if (Personal != null)
            {
                return Personal.ToString();
            }
            else if (RedesDeComunicaciones != null)
            {
                return RedesDeComunicaciones.ToString();
            }
            else if (Servicios != null)
            {
                return Servicios.ToString();
            }
            else if (Software != null)
            {
                return Software.ToString();
            }

            return null;
        }
    }
}