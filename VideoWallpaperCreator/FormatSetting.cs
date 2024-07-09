using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace VideoWallpaperCreator
{   
    [DefaultPropertyAttribute("Name")]
    public class FormatSetting
    {
        /*
        [CategoryAttribute("Audio Stream"), DescriptionAttribute("")]
        [DisplayName("Profile Name")]
        public string Name
        {
            get;
            set;
        }

        [CategoryAttribute("Audio Stream"), DescriptionAttribute("")]
        [DisplayName("Format")]
        [TypeConverter(typeof(FormatConverter))]
        public string Format
        {
            get;
            set;
        }
        */

        [CategoryAttribute("Audio Stream"), DescriptionAttribute("")]
        [TypeConverter(typeof(SamplingRateConverter))]
        [DisplayName("Sampling Rate (Hz)")]
        public string SamplingRate
        {
            get;
            set;
        }

        [CategoryAttribute("Audio Stream"), DescriptionAttribute("")]
        [DisplayName("Bitrate (KB/s)")]
        [TypeConverter(typeof(BitRateConverter))]
        public string BitRate
        {
            get;
            set;
        }

        [CategoryAttribute("Audio Stream"), DescriptionAttribute("")]
        [DisplayName("Audio Channels")]
        [TypeConverter(typeof(AudioChannelsConverter))]
        public string AudioChannels
        {
            get;
            set;
        }

        [CategoryAttribute("Audio Stream"), DescriptionAttribute("")]
        [DisplayName("Volume Control")]
        [TypeConverter(typeof(VolumeControlConverter))]
        public string VolumeControl
        {
            get;
            set;
        }

        [CategoryAttribute("Audio Stream"), DescriptionAttribute("")]
        [DisplayName("Encode Mode")]
        [TypeConverter(typeof(EncodeModeConverter))]
        public string EncodeMode
        {
            get;
            set;
        }

        [CategoryAttribute("Audio Stream"), DescriptionAttribute("")]
        [DisplayName("VBR Quality")]
        [TypeConverter(typeof(VBRQualityConverter))]
        public string VBRQuality
        {
            get;
            set;
        }

        #region metatadata

        [CategoryAttribute("Metadata"), DescriptionAttribute("")]
        [DisplayName("Keep the same Metadata")]
        public bool KeepTheSameMetadata
        {
            get;
            set;
        }

        [CategoryAttribute("Metadata"), DescriptionAttribute("")]
        [DisplayName("Title")]
        public string Title
        {
            get;
            set;
        }

        [CategoryAttribute("Metadata"), DescriptionAttribute("")]
        [DisplayName("Timestamp")]
        public string Timestamp
        {
            get;
            set;
        }

        [CategoryAttribute("Metadata"), DescriptionAttribute("")]
        [DisplayName("Author")]
        public string Author
        {
            get;
            set;
        }

        [CategoryAttribute("Metadata"), DescriptionAttribute("")]
        [DisplayName("Copyright")]
        public string Copyright
        {
            get;
            set;
        }

        [CategoryAttribute("Metadata"), DescriptionAttribute("")]
        [DisplayName("Comment")]
        public string Comment
        {
            get;
            set;
        }

        [CategoryAttribute("Metadata"), DescriptionAttribute("")]
        [DisplayName("Album")]
        public string Album
        {
            get;
            set;
        }

        [CategoryAttribute("Metadata"), DescriptionAttribute("")]
        [DisplayName("Track")]
        public string Track
        {
            get;
            set;
        }

        [CategoryAttribute("Metadata"), DescriptionAttribute("")]
        [DisplayName("Year")]
        public string Year
        {
            get;
            set;
        }

        [CategoryAttribute("Metadata"), DescriptionAttribute("")]
        [DisplayName("ID3v2")]
        public bool ID3v2
        {
            get;
            set;
        }
        #endregion
    }

    public class SamplingRateConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(
                           ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection
                     GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{"48000", 
                                                     "44100", 
                                                     "22050","11025"});
        }

        public override bool GetStandardValuesExclusive(
                           ITypeDescriptorContext context)
        {
            return false;
        }


    }

    public class BitRateConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(
                           ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection
                     GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] { "320k", "256k", "224k", "192k", "128k", "96k", "64k", "32k" });
        }

        public override bool GetStandardValuesExclusive(
                           ITypeDescriptorContext context)
        {
            return false;
        }


    }

    public class AudioChannelsConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(
                           ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection
                     GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{"Stereo - 2 Audio Channels", 
                                                     "Mono - 1 Audio Channel"});
        }

        public override bool GetStandardValuesExclusive(
                           ITypeDescriptorContext context)
        {
            //!
            return true;
        }


    }

    public class VolumeControlConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(
                           ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection
                     GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{"50%", 
                                                     "100%", 
                                                     "150%","200%"});
        }

        public override bool GetStandardValuesExclusive(
                           ITypeDescriptorContext context)
        {
            return false;
        }


    }

    public class FormatConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(
                           ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection
                     GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{"MP3", 
                                                     "FLAC", 
                                                     "AAC","WMA","OGG","WAV","AC3","OPUS","MP2"});
        }

        public override bool GetStandardValuesExclusive(
                           ITypeDescriptorContext context)
        {
            return true ;
        }


    }

    public class EncodeModeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(
                           ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection
                     GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{"CBR", 
                                                     "VBR" 
                                                     });
        }

        public override bool GetStandardValuesExclusive(
                           ITypeDescriptorContext context)
        {
            return true;
        }


    }

    public class VBRQualityConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(
                           ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection
                     GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[]{"0","1","2","3","4","5","6","7","8","9"
                                                     });
        }

        public override bool GetStandardValuesExclusive(
                           ITypeDescriptorContext context)
        {
            return true;
        }


    }
}
