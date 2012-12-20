MonoZSPinAnnotation
===================

ZSPinAnnotation class in Mono, converted from https://github.com/nnhubbard/ZSPinAnnotation

Usage example:

  	public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, MonoTouch.Foundation.NSObject annotation)
		{
			// ignore user location
			if (annotation.GetType() == typeof(MKUserLocation)){
				return null;
			}
			
			// try and dequeu the annotaion view
			MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(annotationIdentifier);
			
			// if we couldn't dequeuq one, create a new one
			if (annotationView == null){
				//annotationView = new MKPinAnnotationView(annotation, annotationIdentifier);
				annotationView = new MKAnnotationView(annotation, annotationIdentifier);
			} else {
				annotationView.Annotation = annotation;
			}
			
			
			// config annotaion view properties

			ZSPinAnnotation pinColor = new ZSPinAnnotation();
			MapAnotation anno = (MapAnotation) annotation;
			annotationView.Image = pinColor.PinAnnotationWithColor(anno.Color);
			annotationView.Enabled = true;
			annotationView.CenterOffset = new System.Drawing.PointF(6.5f, -16);
			annotationView.CalloutOffset = new System.Drawing.PointF(-11, 0);

			annotationView.Selected = true;
			annotationView.CanShowCallout = true;


			// add accessary view
			annotationView.RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure);
			
			return annotationView;
		}
