using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AnimatedImage : MonoBehaviour
{
    [SerializeField, Header("Relative path from StreamingAssets folder")] private List<string> filePath;
        
    private Image _image;
    [SerializeField]
    private List<Sprite> _frames     = new List<Sprite>();
    [SerializeField]
    private List<float>  _frameDelay = new List<float>();

    private int _currentFrame = 0;
    private float _time = 0.0f;
    private int nowIndex;
        
    private void Start()
    {
        nowIndex = 0;
        if (string.IsNullOrWhiteSpace(filePath[0])) return;
        _image = GetComponent<Image>();

        var path = Path.Combine(Application.streamingAssetsPath, filePath[0]);

        using( var decoder = new MG.GIF.Decoder( File.ReadAllBytes( path )))
        {
            var img = decoder.NextImage();

            while( img != null )
            {
                _frames.Add(Texture2DtoSprite(img.CreateTexture()));
                _frameDelay.Add(img.Delay / 1000.0f);
                img = decoder.NextImage();
            }
        }

        _image.sprite = _frames[0];
    }

    private void Update()
    {
        if (_frames == null) return;

        _time += Time.deltaTime;

        if(_currentFrame < _frames.Count && _time >= _frameDelay[ _currentFrame ])
        {
            _currentFrame = ( _currentFrame + 1 );
            if (_currentFrame >= _frames.Count)
            {
                return;
            }
            _time = 0.0f;

            _image.sprite = _frames[_currentFrame];
        }
    }

    private static Sprite Texture2DtoSprite(Texture2D tex)
        => Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
    /// <summary>
    /// gif画像を切り替える処理
    /// </summary>
    /// <param name="Index"></param>
    public void ChangeGif(int Index)
    {
        _frames.Clear();
        _frameDelay.Clear();
        var path = Path.Combine(Application.streamingAssetsPath, filePath[Index]);
        _currentFrame = 0;
        using (var decoder = new MG.GIF.Decoder(File.ReadAllBytes(path)))
        {
            var img = decoder.NextImage();

            while (img != null)
            {
                _frames.Add(Texture2DtoSprite(img.CreateTexture()));
                _frameDelay.Add(img.Delay / 1000.0f);
                img = decoder.NextImage();
            }
        }

        _image.sprite = _frames[0];
    }
}