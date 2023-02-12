﻿// Project:         Daggerfall Tools For Unity
// Copyright:       Copyright (C) 2009-2022 Daggerfall Workshop
// Web Site:        http://www.dfworkshop.net
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Source Code:     https://github.com/Interkarma/daggerfall-unity
// Original Author: Podleron (podleron@gmail.com)

using DaggerfallConnect;
using UnityEngine;

namespace DaggerfallWorkshop.Game.Addons.RmbBlockEditor
{
    #if UNITY_EDITOR
    [ExecuteInEditMode]
    public class Ground: MonoBehaviour
    {
        public DFBlock.RmbGroundTiles[,] groundTiles;
        public DaggerfallGroundPlane ground;
        public ClimateBases climate;
        public ClimateSeason season;
        private MeshFilter meshFilter;
        private MeshCollider groundCollider;

        public void CreateObject(DFBlock.RmbGroundTiles[,] gt, ClimateBases climate, ClimateSeason season)
        {
            groundTiles = gt;
            ground = gameObject.AddComponent<DaggerfallGroundPlane>();
            meshFilter = gameObject.GetComponent<MeshFilter>();
            groundCollider = gameObject.AddComponent<MeshCollider>();

            this.climate = climate;
            this.season = season;

            ground.transform.localPosition += new Vector3(0, 0, -DaggerfallGroundPlane.TileSize / 2.5f);
            Update();
        }

        public void SetClimate(ClimateBases climate, ClimateSeason season)
        {
            this.climate = climate;
            this.season = season;
            Update();
        }
        public void Update()
        {
            RmbBlockHelper.AddGroundPlane(groundTiles, ref ground, ref meshFilter, climate, season);
            groundCollider.sharedMesh = meshFilter.sharedMesh;
        }
    }
    #endif
}