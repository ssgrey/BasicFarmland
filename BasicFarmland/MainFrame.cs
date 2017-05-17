using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicFarmland.Command;

namespace BasicFarmland
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadMapDoc();
        }
        FarmInfo fi = null;
        IMapDocument mapDoc;
        private string pMouseOperate = null;
        IEnvelope pEnv;
        private PointClass pMoveRectPoint;
        private void loadMapDoc()
        {
            mapDoc = new MapDocumentClass();
            try
            {
                System.Windows.Forms.OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "打开地图文档";
                openFileDialog.Filter = "map documents (*.mxd)|*.mxd";
                openFileDialog.ShowDialog();
                string filePath = openFileDialog.FileName;
                mapDoc.Open(filePath, "");
                for (int i = 0; i < mapDoc.MapCount; i++)//
                {
                    axMapControl1.Map = mapDoc.get_Map(i);
                }
                axMapControl1.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void saveDoc()
        {
            try
            {
                string sMxdFileName = axMapControl1.DocumentFilename;
                IMapDocument pMapDocument = new MapDocumentClass();
                if (sMxdFileName != null && axMapControl1.CheckMxFile(sMxdFileName))
                {
                    if (pMapDocument.get_IsReadOnly(sMxdFileName))
                    {
                        MessageBox.Show("本地图文档是只读的，不能保存!");
                        pMapDocument.Close();
                        return;
                    }
                }
                else
                {
                    SaveFileDialog pSaveFileDialog = new SaveFileDialog();
                    pSaveFileDialog.Title = "请选择保存路径";
                    pSaveFileDialog.OverwritePrompt = true;
                    pSaveFileDialog.Filter = "ArcMap文档（*.mxd）|*.mxd|ArcMap模板（*.mxt）|*.mxt";
                    pSaveFileDialog.RestoreDirectory = true;
                    if (pSaveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        sMxdFileName = pSaveFileDialog.FileName;
                    }
                    else
                    {
                        return;
                    }
                }
                pMapDocument.New(sMxdFileName);
                pMapDocument.ReplaceContents(axMapControl1.Map as IMxdContents);
                pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                pMapDocument.Close();
                MessageBox.Show("保存地图文档成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDoc();
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMapDocument doc = new MapDocumentClass();

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "另存为";
            saveDialog.OverwritePrompt = true;
            saveDialog.RestoreDirectory = true;
            saveDialog.Filter = "ArcMap文档（*.mxd）|*.mxd|ArcMap模板（*.mxt）|*.mxt";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                String filename = saveDialog.FileName;
                doc.New(filename);
                doc.ReplaceContents(axMapControl1.Map as IMxdContents);
                doc.Save(doc.UsesRelativePaths, true);
                doc.Close();
                MessageBox.Show("保存地图文档成功!");
            }
        }

        private void zoomFixedIn_Click(object sender, EventArgs e)
        {
            IEnvelope pEnvelope;
            pEnvelope = axMapControl1.Extent;
            pEnvelope.Expand(2, 2, true);     
            axMapControl1.Extent = pEnvelope;
            axMapControl1.ActiveView.Refresh();
        }

        private void zoomFixedOut_Click(object sender, EventArgs e)
        {
            IEnvelope pEnvelope;
            pEnvelope = axMapControl1.Extent;
            pEnvelope.Expand(0.5, 0.5, true);     
            axMapControl1.Extent = pEnvelope;
            axMapControl1.ActiveView.Refresh();
        }

        private void fullExtend_Click(object sender, EventArgs e)
        {

            axMapControl1.Extent = axMapControl1.FullExtent;
            axMapControl1.ActiveView.Refresh();
        }

        private void zoomOut_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            pMouseOperate = "ZoomOut";
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomOut;
        }

        private void zoomIn_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            pMouseOperate = "ZoomIn";
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomIn;
        }

        private void Pan_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            pMouseOperate = "Pan";
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerPan;
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            axMapControl2.Extent = axMapControl1.FullExtent;//设置鹰眼范围           
            pEnv = axMapControl2.Extent;  //获取鹰眼范围
            DrawRectangle(pEnv);  //绘制红色矩形框
        }
        private void DrawRectangle(IEnvelope pEnvelope)
        {
            //在绘制前，清除鹰眼中之前绘制的矩形框
            IGraphicsContainer pGraphicsContainer = axMapControl2.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            pGraphicsContainer.DeleteAllElements();
            //得到当前视图范围
            IRectangleElement pRectangleElement = new RectangleElementClass();
            IElement pElement = pRectangleElement as IElement;
            pElement.Geometry = pEnvelope;
            //设置矩形框（实质为中间透明度面）
            IRgbColor pColor = new RgbColorClass();
            pColor = GetRgbColor(255, 0, 0);
            pColor.Transparency = 255;
            ILineSymbol pOutLine = new SimpleLineSymbolClass();
            pOutLine.Width = 2;
            pOutLine.Color = pColor;

            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pColor = new RgbColorClass();
            pColor.Transparency = 0;
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutLine;
            //向鹰眼中添加矩形框
            IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
            pFillShapeElement.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeElement, 0);
            //刷新
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        private IRgbColor GetRgbColor(int intR, int intG, int intB)
        {
            IRgbColor pRgbColor = null;
            if (intR < 0 || intR > 255 || intG < 0 || intG > 255 || intB < 0 || intB > 255)
            {
                return pRgbColor;
            }
            pRgbColor = new RgbColorClass();
            pRgbColor.Red = intR;
            pRgbColor.Green = intG;
            pRgbColor.Blue = intB;
            return pRgbColor;
        }

        private void 漫游ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            pMouseOperate = "Pan";
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerPan;
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //屏幕坐标点转化为地图坐标点
            //pPointPt = (axMapControl1.Map as IActiveView).ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
            IGeometry geometry = null;
           // FormSelection formSelection = new FormSelection();
            if (e.button == 1)//左键
            {
                IActiveView pActiveView = axMapControl1.ActiveView;
                IEnvelope pEnvelope = new EnvelopeClass();

                switch (pMouseOperate)
                {
                    #region 拉框放大

                    case "ZoomIn":
                        pEnvelope = axMapControl1.TrackRectangle();
                        //如果拉框范围为空则返回
                        if (pEnvelope == null || pEnvelope.IsEmpty || pEnvelope.Height == 0 || pEnvelope.Width == 0)
                        {
                            return;
                        }
                        //如果有拉框范围，则放大到拉框范围
                        pActiveView.Extent = pEnvelope;
                        pActiveView.Refresh();
                        break;

                    #endregion

                    #region 拉框缩小

                    case "ZoomOut":
                        pEnvelope = axMapControl1.TrackRectangle();

                        //如果拉框范围为空则退出
                        if (pEnvelope == null || pEnvelope.IsEmpty || pEnvelope.Height == 0 || pEnvelope.Width == 0)
                        {
                            return;
                        }
                        //如果有拉框范围，则以拉框范围为中心，缩小倍数为：当前视图范围/拉框范围
                        else
                        {
                            double dWidth = pActiveView.Extent.Width * pActiveView.Extent.Width / pEnvelope.Width;
                            double dHeight = pActiveView.Extent.Height * pActiveView.Extent.Height / pEnvelope.Height;
                            double dXmin = pActiveView.Extent.XMin -
                                           ((pEnvelope.XMin - pActiveView.Extent.XMin) * pActiveView.Extent.Width /
                                            pEnvelope.Width);
                            double dYmin = pActiveView.Extent.YMin -
                                           ((pEnvelope.YMin - pActiveView.Extent.YMin) * pActiveView.Extent.Height /
                                            pEnvelope.Height);
                            double dXmax = dXmin + dWidth;
                            double dYmax = dYmin + dHeight;
                            pEnvelope.PutCoords(dXmin, dYmin, dXmax, dYmax);
                        }
                        pActiveView.Extent = pEnvelope;
                        pActiveView.Refresh();
                        break;

                    #endregion

                    #region 漫游

                    case "Pan":
                        axMapControl1.Pan();
                        break;

                    #endregion

                    //#region 选择要素

                    //case "SelFeature":
                    //    IEnvelope pEnv = mainMapControl.TrackRectangle();
                    //    IGeometry pGeo = pEnv as IGeometry;
                    //    //矩形框若为空，即为点选时，对点范围进行扩展
                    //    if (pEnv.IsEmpty == true)
                    //    {
                    //        tagRECT r;
                    //        r.left = e.x - 5;
                    //        r.top = e.y - 5;
                    //        r.right = e.x + 5;
                    //        r.bottom = e.y + 5;
                    //        pActiveView.ScreenDisplay.DisplayTransformation.TransformRect(pEnv, ref r, 4);
                    //        pEnv.SpatialReference = pActiveView.FocusMap.SpatialReference;
                    //    }
                    //    pGeo = pEnv as IGeometry;
                    //    mainMapControl.Map.SelectByShape(pGeo, null, false);
                    //    mainMapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                    //    break;

                    //#endregion

                    //#region 区域导出
                    //case "ExportRegion":
                    //    //删除视图中数据
                    //    mainMapControl.ActiveView.GraphicsContainer.DeleteAllElements();
                    //    mainMapControl.ActiveView.Refresh();
                    //    IPolygon pPolygon = DrawPolygon(mainMapControl);
                    //    if (pPolygon == null) return;
                    //    ExportMap.AddElement(pPolygon, mainMapControl.ActiveView);
                    //    if (frmExpMap == null || frmExpMap.IsDisposed)
                    //    {
                    //        frmExpMap = new FormExportMap(mainMapControl);
                    //    }
                    //    frmExpMap.IsRegion = true;
                    //    frmExpMap.GetGeometry = pPolygon as IGeometry;
                    //    frmExpMap.Show();
                    //    frmExpMap.Activate();
                    //    break;
                    //#endregion

                    //#region 距离量算
                    //case "MeasureLength":
                    //    //判断追踪线对象是否为空，若是则实例化并设置当前鼠标点为起始点
                    //    if (pNewLineFeedback == null)
                    //    {
                    //        //实例化追踪线对象
                    //        pNewLineFeedback = new NewLineFeedbackClass();
                    //        pNewLineFeedback.Display = (mainMapControl.Map as IActiveView).ScreenDisplay;
                    //        //设置起点，开始动态线绘制
                    //        pNewLineFeedback.Start(pPointPt);
                    //        dToltalLength = 0;
                    //    }
                    //    else //如果追踪线对象不为空，则添加当前鼠标点
                    //    {
                    //        pNewLineFeedback.AddPoint(pPointPt);
                    //    }
                    //    //pGeometry = m_PointPt;
                    //    if (dSegmentLength != 0)
                    //    {
                    //        dToltalLength = dToltalLength + dSegmentLength;
                    //    }
                    //    break;
                    //#endregion

                    //#region 面积量算
                    //case "MeasureArea":
                    //    if (pNewPolygonFeedback == null)
                    //    {
                    //        //实例化追踪面对象
                    //        pNewPolygonFeedback = new NewPolygonFeedback();
                    //        pNewPolygonFeedback.Display = (mainMapControl.Map as IActiveView).ScreenDisplay;
                    //        ;
                    //        pAreaPointCol.RemovePoints(0, pAreaPointCol.PointCount);
                    //        //开始绘制多边形
                    //        pNewPolygonFeedback.Start(pPointPt);
                    //        pAreaPointCol.AddPoint(pPointPt, ref missing, ref missing);
                    //    }
                    //    else
                    //    {
                    //        pNewPolygonFeedback.AddPoint(pPointPt);
                    //        pAreaPointCol.AddPoint(pPointPt, ref missing, ref missing);
                    //    }
                    //    break;
                    //#endregion

                    //#region 要素选择
                    //case "SelectFeature":
                    //    IPoint point = new PointClass();
                    //    IGeometry pGeometry = point as IGeometry;
                    //    mainMapControl.Map.SelectByShape(pGeometry, null, false);
                    //    mainMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                    //    break;
                    //#endregion
                 /*  #region 点选
                    case "PointSel":
                        
                        ESRI.ArcGIS.Geometry.Point pt = new ESRI.ArcGIS.Geometry.Point();
                        pt.X = e.mapX;
                        pt.Y = e.mapY;
                        geometry = pt as IGeometry;
                        axMapControl1.Map.SelectByShape(geometry, null, false);
                        axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                        MessageBox.Show("点选");
                        //将当前主窗体中MapControl控件中的Map对象赋值给FormQueryByAttribute窗体的CurrentMap属性
                        //formSelection.CurrentMap = axMapControl1.Map;
                        //显示属性查询窗体
                       // formSelection.Show();
                        break;
                    #endregion*/
              /*      #region 框选
                    case "RecSel":
                        geometry = axMapControl1.TrackRectangle();
                        axMapControl1.Map.SelectByShape(geometry, null, false);
                        axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

                        //将当前主窗体中MapControl控件中的Map对象赋值给FormQueryByAttribute窗体的CurrentMap属性
                        formSelection.CurrentMap = axMapControl1.Map;
                        //显示属性查询窗体
                        formSelection.Show();
                        break;
                    #endregion */
             /*       #region 圆选
                    case "CircleSel":
                        geometry = axMapControl1.TrackCircle();
                        axMapControl1.Map.SelectByShape(geometry, null, false);
                        axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

                        //将当前主窗体中MapControl控件中的Map对象赋值给FormQueryByAttribute窗体的CurrentMap属性
                        formSelection.CurrentMap = axMapControl1.Map;
                        //显示属性查询窗体
                        formSelection.Show();
                        break;
                    #endregion*/
                      #region 点选
                case "NTinfo":
                 /*  ESRI.ArcGIS.Geometry.Point pt1 = new ESRI.ArcGIS.Geometry.Point();
                    pt1.X = e.mapX;
                    pt1.Y = e.mapY;
                    axMapControl1.Map.SelectByShape(pt1.Envelope, null, false);*///不能用点，地类图斑图层都是面元素
               
                    IGeometry g = null;  
                    IEnvelope pEnv;  
                    IActiveView pActiveView1 = axMapControl1.ActiveView;  
                    IMap pMap = axMapControl1.Map;  
                    pEnv = axMapControl1.TrackRectangle();  
                    if (pEnv.IsEmpty == true)  
                    {
                        ESRI.ArcGIS.esriSystem.tagRECT r;  
                        r.bottom = e.y + 5;  
                        r.top = e.y - 5;  
                        r.left = e.x - 5;  
                        r.right = e.x + 5;  
                        pActiveView.ScreenDisplay.DisplayTransformation.TransformRect(pEnv, ref r, 4);  
                        pEnv.SpatialReference = pActiveView.FocusMap.SpatialReference;  
                    }  
                    g = pEnv as IGeometry;  
                    axMapControl1.Map.SelectByShape(g, null, false);  
                    axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);                            

                    //获取选取的要素集
                  IEnumFeature pEnumFeature = axMapControl1.Map.FeatureSelection as IEnumFeature;
                    IFeature pFeature = pEnumFeature.Next();
                    while (pFeature != null)
                    {
                        //string str1 = pFeature.OID.ToString();
                        string str2 = pFeature.get_Value(2).ToString();
                        MessageBox.Show( "图斑号:"+Convert.ToInt32(str2));
                        pFeature = pEnumFeature.Next();
                        if (fi == null || fi.IsDisposed)
                        {
                            fi = new FarmInfo();
                            fi.currentMap = axMapControl1.Map;
                            fi.Show();
                        }
                        fi.setTBH(Convert.ToInt32(str2));

                    }

                    break;
                #endregion
                    default:
                        break;
                }
            }
            else if (e.button == 2)
            {
                pMouseOperate = "";
                axMapControl1.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }
        }

        private double ConvertPixelsToMapUnits(IActiveView pActiveView, double pixelUnits)
        {
            // Uses the ratio of the size of the map in pixels to map units to do the conversion  
            IPoint p1 = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.UpperLeft;
            IPoint p2 = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.UpperRight;
            int x1, x2, y1, y2;
            pActiveView.ScreenDisplay.DisplayTransformation.FromMapPoint(p1, out x1, out y1);
            pActiveView.ScreenDisplay.DisplayTransformation.FromMapPoint(p2, out x2, out y2);
            double pixelExtent = x2 - x1;
            double realWorldDisplayExtent = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.Width;
            double sizeOfOnePixel = realWorldDisplayExtent / pixelExtent;
            return pixelUnits * sizeOfOnePixel;
        }  

        private void 拉框放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            pMouseOperate = "ZoomIn";
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomIn;
        }

        private void 拉框缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            pMouseOperate = "ZoomOut";
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomOut;
        }

        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            SynchronizeEagleEye();
        }
        private void SynchronizeEagleEye()
        {
            if (axMapControl2.LayerCount > 0)
            {
                axMapControl2.ClearLayers();
            }
            //设置鹰眼和主地图的坐标系统一致
            axMapControl2.SpatialReference = axMapControl1.SpatialReference;
            for (int i = axMapControl1.LayerCount - 1; i >= 0; i--)
            {
                //使鹰眼视图与数据视图的图层上下顺序保持一致
                ILayer pLayer = axMapControl1.get_Layer(i);

                if (pLayer is IGroupLayer || pLayer is ICompositeLayer)
                {
                    ICompositeLayer pCompositeLayer = (ICompositeLayer)pLayer;
                    for (int j = pCompositeLayer.Count - 1; j >= 0; j--)
                    {
                        ILayer pSubLayer = pCompositeLayer.get_Layer(j);
                        IFeatureLayer pFeatureLayer = pSubLayer as IFeatureLayer;
                        if (pFeatureLayer != null)
                        {
                            //由于鹰眼地图较小，所以过滤点图层不添加
                            if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint
                                && pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint)
                            {
                                axMapControl2.AddLayer(pLayer);
                            }
                        }
                    }
                }
                else
                {
                    //IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                    //if (pFeatureLayer != null)
                    //{
                    //    if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint
                    //        && pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint)
                    //    {
                    axMapControl2.AddLayer(pLayer);
                    //}
                    //}
                }
                //设置鹰眼地图全图显示  
                axMapControl2.Extent = axMapControl1.FullExtent;
                pEnv = axMapControl1.Extent as IEnvelope;
                DrawRectangle(pEnv);
                axMapControl2.ActiveView.Refresh();
            }
        }

        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (axMapControl2.Map.LayerCount > 0)
            {
                //按下鼠标左键移动矩形框
                if (e.button == 1)
                {
                    //如果指针落在鹰眼的矩形框中，标记可移动

                    pMoveRectPoint = new PointClass();
                    pMoveRectPoint.PutCoords(e.mapX, e.mapY);  //记录点击的第一个点的坐标
                }

            }
        }

        private void axMapControl2_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (e.button == 1 && pMoveRectPoint != null)
            {
                if (e.mapX == pMoveRectPoint.X && e.mapY == pMoveRectPoint.Y)
                {
                    axMapControl1.CenterAt(pMoveRectPoint);
                }

            }
        }

        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            //得到当前视图范围
            pEnv = (IEnvelope)e.newEnvelope;
            DrawRectangle(pEnv);
        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            IBasicMap pMap = null;
            ILayer pLayer = null;
            object legendgp = null;
            object index = null;
            ToolbarMenu m_pMenuLayer = new ToolbarMenu();
            esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
            try
            {
                axTOCControl1.HitTest(e.x, e.y,ref pItem,ref pMap,ref pLayer,ref legendgp,ref index);
            }
            catch (Exception)
            {
                throw;
            }
            switch (e.button)
            {
                case 2:
                    if (pItem == esriTOCControlItem.esriTOCControlItemMap)
                    {
                        axTOCControl1.SelectItem(pMap, null);
                    }
                    else
                    {
                        axTOCControl1.SelectItem(pLayer, null);
                    }
                    axMapControl1.CustomProperty = pLayer;
                    if (pItem == esriTOCControlItem.esriTOCControlItemMap)
                    {
                        //.............右键map时
                    }
                    if (pItem == esriTOCControlItem.esriTOCControlItemLayer)
                    {
                        m_pMenuLayer.AddItem(new RemoveLayer(), -1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
                        m_pMenuLayer.AddItem(new ZoomToLayer(), -1, 1, false, esriCommandStyles.esriCommandStyleTextOnly);
                        m_pMenuLayer.AddItem(new LayerVisibility(), 1, 2, true, esriCommandStyles.esriCommandStyleTextOnly);
                        m_pMenuLayer.AddItem(new LayerVisibility(), 2,3, false, esriCommandStyles.esriCommandStyleTextOnly);
                        m_pMenuLayer.AddItem(new OpenAttribute(pLayer), -1, 4, true, esriCommandStyles.esriCommandStyleTextOnly);
                        m_pMenuLayer.SetHook(axMapControl1);
                        m_pMenuLayer.PopupMenu(e.x, e.y, axTOCControl1.hWnd);
                    }
                    break;

            }



        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAdd ua = new UserAdd();
            ua.ShowDialog();
        }

        private void 修改用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserModify um = new UserModify();
            um.ShowDialog();
        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDelete ud = new UserDelete();
            ud.ShowDialog();
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 基本农田信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (fi==null || fi.IsDisposed)
            {
                fi = new FarmInfo();
                fi.currentMap = axMapControl1.Map;
                fi.Show();
            }
        }

        private void 责任人信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonInfo pif = new PersonInfo();
            pif.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            saveDoc();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            pMouseOperate = "NTinfo";
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerArrowQuestion;
          //  fi.setTBH(3);
        }

        private void 基本农田查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConditionFind cf = new ConditionFind();
            cf.map = axMapControl1.Map;
            cf.ShowDialog();
        }

    }
}
